import { Component, OnInit } from '@angular/core';
import { Classes } from 'src/app/models/classes';
import { ClassesService } from 'src/app/services/classes.service';

@Component({
  selector: 'app-classes',
  templateUrl: './classes.component.html',
  styleUrls: ['./classes.component.scss']
})
export class ClassesComponent implements OnInit {

  classes: Classes[] = [];
  displayedColumns = ['name', 'academicValue', 'weeklyHours']
  constructor(private classesService: ClassesService) { }

  ngOnInit(): void {
    this.getData();
  }

  getData() {
    this.classesService.GetClasses()
      .subscribe({
        next: ({entities}) => {
          console.log(entities)
          this.classes = entities as Classes[];
        }
      })
  }
}
