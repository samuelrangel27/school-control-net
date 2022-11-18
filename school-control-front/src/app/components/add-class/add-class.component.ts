import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClassesService } from 'src/app/services/classes.service';
import { ToastrService } from 'ngx-toastr';
import { setTimeout } from 'timers';

@Component({
  selector: 'app-add-class',
  templateUrl: './add-class.component.html',
  styleUrls: ['./add-class.component.scss']
})
export class AddClassComponent implements OnInit {

  classForm = new FormGroup({
    name: new FormControl('',Validators.required),
    academicValue: new FormControl('', Validators.required),
    weeklyHours: new FormControl('', Validators.required)
  });

  constructor(private classService: ClassesService,
    private toastr: ToastrService,
    private router: Router) { }

  ngOnInit(): void {
  }

  save(){
    this.classService
      .Save(this.classForm.value)
      .subscribe((x: any) => {
        this.toastr.success(x.message);
        this.classForm.reset();
      }, error => {
        console.log(error)
      })
  }
  
  cancel() {
    if(this.classForm.dirty){

    }
    else{
      this.router.navigate(['/classes']);
    }
  }
}
