import { Component, HostListener } from '@angular/core';
import { Rectangle } from 'src/app/models/rectangle';
import { RectangleService } from 'src/app/services/rectangle.service';

@Component({
  selector: 'app-rectangle',
  templateUrl: './rectangle.component.html',
  styleUrls: ['./rectangle.component.css']
})

export class RectangleComponent {
  rectangle = new Rectangle();
  resizing = false;
  initialX= 0;
  initialY = 0;
  initialWidth = 0;
  initialHeight = 0;

  constructor(private rectangleService : RectangleService){}
  
  ngOnInit() :void {
    this.rectangleService.GetRectangle().subscribe(result=>{
      
      if(result.success){
        this.rectangle = result.data as Rectangle
        return;
      }

      alert(result.error)
    });
}

onResizeStart(event : MouseEvent) {  
  this.resizing = true;
  this.initialX = event.clientX;
  this.initialY = event.clientY;
}

@HostListener('window:mousemove', ['$event'])
onResize(event: MouseEvent) {
  if (!this.resizing) {
    return; 
  }

  this.rectangle.width = this.rectangle.width + event.clientX - this.initialX;
  this.rectangle.height = this.rectangle.height + event.clientY - this.initialY;

  this.CalculatePerimeter();

  this.initialX = event.clientX;
  this.initialY = event.clientY;
}

CalculatePerimeter () : void {
  this.rectangle.perimeter = 2 * (this.rectangle.width + this.rectangle.height);
}

@HostListener('window:mouseup', ['$event'])
resizeStop(event: MouseEvent) {
  if (!this.resizing) {
    return;
  }

  this.resizing = false;

  this.rectangleService.SaveRectangle(this.rectangle).subscribe(result => {
    if (result.success) {
      this.rectangle = result.data as Rectangle;
    }
  });
}

}
