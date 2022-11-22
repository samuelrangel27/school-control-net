import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ODataEntitySetService, ODataServiceFactory } from 'angular-odata';
import { first, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Classes } from '../models/classes';

@Injectable({
  providedIn: 'root'
})
export class ClassesService {
  private classesEntityService: ODataEntitySetService<Classes>;
  constructor(private odataFactory: ODataServiceFactory,
    private http: HttpClient) { 
    this.classesEntityService = this.odataFactory.entitySet<Classes>('Classes');
  }

  GetClasses(page:any){
    const entityResourceSet = this.classesEntityService.entities();
    return entityResourceSet
      .query(q => {
        q.skip(page.pageIndex * page.pageSize);
        q.top(page.pageSize);
      })
      .fetch({withCount: true, });
  }

  GetClassesById(id: number){
    const entityResourceSet = this.classesEntityService.entities();
    return entityResourceSet.query(q => q.filter({id: id}))
      .fetch()
      .pipe(map(x => x.entities as Classes[]))
      .pipe(map(x => x[0]));
  }

  Save(classes: Classes) {
    return this.http.post(`${environment.rootUrl}Class`, classes);
  }

  Update(classes: Classes) {
    return this.http.put(`${environment.rootUrl}Class`, classes);
  }
}
