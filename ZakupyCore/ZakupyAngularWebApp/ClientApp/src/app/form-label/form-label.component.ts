import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-form-label',
  templateUrl: './form-label.component.html',
  styleUrls: ['./form-label.component.css']
})
export class FormLabelComponent implements OnInit {

  @Input() text: string;
  @Input() controlID: string;

  constructor() { }

  ngOnInit() {
    console.log('Text: ' + this.text + ', controlID:' + this.controlID);
  }

}
