import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClassesService } from 'src/app/services/classes.service';
import { ToastrService } from 'ngx-toastr';
import { setTimeout } from 'timers';
import { Classes } from 'src/app/models/classes';

@Component({
  selector: 'app-add-class',
  templateUrl: './add-class.component.html',
  styleUrls: ['./add-class.component.scss']
})
export class AddClassComponent implements OnInit {

  title: string = 'New Class';
  id: number = 0;

  classForm = new FormGroup({
    name: new FormControl('',Validators.required),
    academicValue: new FormControl('', Validators.required),
    weeklyHours: new FormControl('', Validators.required)
  });

  constructor(private classService: ClassesService,
    private toastr: ToastrService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      console.log(params['id'])
      const id = Number(params['id']);
      if(!Number.isNaN(id)){
        this.id = id;
        this.classService.GetClassesById(id)
          .subscribe({
            next: data => {
              console.log(data);
              this.title = 'Edit class'
              this.classForm.patchValue(data)
            }
          })
      }
    })
  }

  save(){
    const classes = this.classForm.value as Classes;
    if(this.id !== 0)
    {
      classes.id = this.id;
      this.classService.Update(classes)
        .subscribe({
          next : (res:any) => {
            this.toastr.success(res.message);
            this.router.navigate(['/classes']);
          }
        })
    }
    else {
      this.classService
        .Save(classes)
        .subscribe((x: any) => {
          this.toastr.success(x.message);
          this.classForm.reset();
        }, error => {
          console.log(error)
        })
    }
  }
  
  cancel() {
    if(this.classForm.dirty){

    }
    else{
      this.router.navigate(['/classes']);
    }
  }
}
