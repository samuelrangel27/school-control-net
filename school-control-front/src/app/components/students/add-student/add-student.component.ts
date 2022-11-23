import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Student } from 'src/app/models/student';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.scss']
})
export class AddStudentComponent implements OnInit {

  title: string = 'New Student';
  id: number = 0;

  studentForm = new FormGroup({
    name: new FormControl('',Validators.required),
    address: new FormControl('', Validators.required),
    dateOfBirth: new FormControl('', Validators.required)
  });

  constructor(private studentsService: StudentService,
    private toastr: ToastrService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      console.log(params['id'])
      const id = Number(params['id']);
      if(!Number.isNaN(id)){
        this.id = id;
        this.studentsService.GetStudentById(id)
          .subscribe({
            next: data => {
              console.log(data);
              this.title = 'Edit Student'
              this.studentForm.patchValue(data)
            }
          })
      }
    })
  }

  save(){
    const student = this.studentForm.value as Student;
    if(this.id !== 0)
    {
      student.id = this.id;
      this.studentsService.Update(student)
        .subscribe({
          next : (res:any) => {
            this.toastr.success(res.message);
            this.router.navigate(['/Students']);
          }
        })
    }
    else {
      this.studentsService
        .Save(student)
        .subscribe({
          next: (x: any) => {
            this.toastr.success(x.message);
            this.studentForm.reset();
          },
          error: error => {
            console.log(error)
          }
        })
    }
  }
  
  cancel() {
    if(this.studentForm.dirty){

    }
    else{
      this.router.navigate(['/students']);
    }
  }
}
