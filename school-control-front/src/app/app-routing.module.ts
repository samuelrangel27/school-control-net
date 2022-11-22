import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddClassComponent } from './components/add-class/add-class.component';
import { ClassesComponent } from './components/classes/classes.component';

const routes: Routes = [
  { path:'classes', component: ClassesComponent},
  { path:'add-class', component: AddClassComponent},
  { path: 'classes/:id/edit', component: AddClassComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
