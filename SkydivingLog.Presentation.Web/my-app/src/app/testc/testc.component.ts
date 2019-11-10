import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'testc',
  templateUrl: './testc.component.html',
  styleUrls: ['./testc.component.scss']
})
export class TESTCComponent implements OnInit {
  @Input() parentCount: number;
  clicked : number;
  constructor() { 
    this.clicked = 0;
  } 

  ngOnInit() {
  }

  clickedBtn = function(){
    this.clicked++;
  }

}
