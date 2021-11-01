import { Component, OnInit } from '@angular/core';
import { SystemManagementService } from '../services/system-management.service';

@Component({
  selector: 'lib-system-management',
  template: ` <p>system-management works!</p> `,
  styles: [],
})
export class SystemManagementComponent implements OnInit {
  constructor(private service: SystemManagementService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
