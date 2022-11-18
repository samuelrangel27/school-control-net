import { Injectable } from '@angular/core';
import { ODataEntitySetService, ODataServiceFactory } from 'angular-odata';
import { Classes } from '../models/classes';

@Injectable({
  providedIn: 'root'
})
export class ClassesService {
  private classesEntityService: ODataEntitySetService<Classes>;
  constructor(private odataFactory: ODataServiceFactory) { 
    this.classesEntityService = this.odataFactory.entitySet<Classes>('Classes');
  }

  GetClasses(){
    const entityResourceSet = this.classesEntityService.entities();
    return entityResourceSet.fetch({withCount: true});
  }
}
