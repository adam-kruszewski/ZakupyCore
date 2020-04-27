import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-validation-info',
  templateUrl: './validation-info.component.html',
  styleUrls: []
})
export class ValidationInfoComponent implements OnInit {

  @Input() control: any;
  @Input() controlLabel: string;

  constructor() { }

  ngOnInit() {
    window.alert('validation on init');
  }

}
