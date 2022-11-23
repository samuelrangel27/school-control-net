import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddClassComponent } from './components/add-class/add-class.component';
import { ClassesComponent } from './components/classes/classes.component';
import { AddStudentComponent } from './components/students/add-student/add-student.component';
import { StudentsComponent } from './components/students/students.component';

const routes: Routes = [
  { path:'classes', component: ClassesComponent},
  { path:'add-class', component: AddClassComponent},
  { path: 'classes/:id/edit', component: AddClassComponent },
  { path:'students', component: StudentsComponent},
  { path:'add-student', component: AddStudentComponent},
  { path: 'students/:id/edit', component: AddStudentComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
