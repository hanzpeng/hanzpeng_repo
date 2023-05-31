import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  constructor(private route:ActivatedRoute){}
  productId$: any; 
  ngOnInit(): void {
    this.productId$ = this.route.paramMap
    .pipe(map(params => params.get('id')));
  }
}
