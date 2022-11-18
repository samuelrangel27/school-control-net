import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ODataEntitySetService, ODataServiceFactory } from 'angular-odata';
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

  GetClasses(){
    const entityResourceSet = this.classesEntityService.entities();
    return entityResourceSet.fetch({withCount: true});
  }

  Save(classes: Classes) {
    return this.http.post(`${environment.rootUrl}Class`, classes);
  }
}
