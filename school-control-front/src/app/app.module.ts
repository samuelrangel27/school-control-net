import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './common/menu/menu.component';
import { MatCardModule} from '@angular/material/card'
import { MatSidenavModule} from '@angular/material/sidenav'
import { MatListModule} from '@angular/material/list';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { MatIconModule} from '@angular/material/icon'
import { MatToolbarModule} from '@angular/material/toolbar';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule, MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ClassesComponent } from './components/classes/classes.component';
import { AddClassComponent } from './components/add-class/add-class.component';
import { ODataModule } from 'angular-odata';
import { environment } from 'src/environments/environment';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { AgGridModule } from 'ag-grid-angular';
import { StudentsComponent } from './components/students/students.component';
import { AddStudentComponent } from './components/students/add-student/add-student.component';
import { MatNativeDateModule } from '@angular/material/core';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    ClassesComponent,
    AddClassComponent,
    StudentsComponent,
    AddStudentComponent
  ],
  imports: [
    BrowserModule,
    MatCardModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    MatToolbarModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AgGridModule,
    ToastrModule.forRoot(),
    ReactiveFormsModule,
    HttpClientModule,
    ODataModule.forRoot({ serviceRootUrl: environment.odataUrl})
  ],
  providers: [
    {provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: {appearance: 'outline'}}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
