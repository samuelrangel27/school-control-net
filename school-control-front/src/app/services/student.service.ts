import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ODataEntitySetService, ODataServiceFactory } from 'angular-odata';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Student } from '../models/student';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private studentsEntityService: ODataEntitySetService<Student>;
  constructor(private odataFactory: ODataServiceFactory,
    private http: HttpClient) { 
      this.studentsEntityService = this.odataFactory.entitySet<Student>('Student');
  }

  GetStudents(page:any){
    const entityResourceSet = this.studentsEntityService.entities();
    return entityResourceSet
      .query(q => {
        q.skip(page.pageIndex * page.pageSize);
        q.top(page.pageSize);
      })
      .fetch({withCount: true, });
  }

  GetStudentById(id: number){
    const entityResourceSet = this.studentsEntityService.entities();
    return entityResourceSet.query(q => q.filter({id: id}))
      .fetch()
      .pipe(map(x => x.entities as Student[]))
      .pipe(map(x => x[0]));
  }

  Save(student: Student) {
    return this.http.post(`${environment.rootUrl}Student`, student);
  }

  Update(student: Student) {
    return this.http.put(`${environment.rootUrl}Student`, student);
  }
}
