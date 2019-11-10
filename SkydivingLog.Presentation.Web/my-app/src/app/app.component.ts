import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'my-app';
  countClicked = 0;

  onClickMe = function(){
    this.countClicked++;
    console.log("Button was clicked count is", this.countClicked);
  }
}
