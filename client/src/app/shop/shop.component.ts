import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { error } from 'protractor';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  @ViewChild('search',{static:true}) searchTerm:ElementRef;
  products:IProduct[];
  brands : IBrand[];
  types : IType[];
  shopParams =  new ShopParams();
  totalCount:number;
  sortOptions=[
    {name:'Alphabetical',value:'name'},
    {name:'Price: Low to High',value:'priceAsc'},
    {name:'Price: High to Low',value:'priceDesc'}

  ];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).
    subscribe(Response => {
      this.products = Response.data;
      this.shopParams.pageNumber = Response.pageIndex;
      this.shopParams.pageSize = Response.pageSize;
      this.totalCount = Response.count;
    },error => {
      console.log(error);
    } )
  }
  getBrands() {
    this.shopService.getBrands().subscribe(Response => {
      this.brands = [{id:0,name:'All'},...Response];
    }, error =>{
      console.log(error);
    })
}
  getTypes() {
  this.shopService.getTypes().subscribe(Response => {
    this.types = [{id:0,name:'All'},...Response];
  }, error =>{
    console.log(error);
  })
}

  onBrandSelected (brandId:number) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1; 
    this.getProducts();

  }
  onTypeSelected (typeId:number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1; 
    this.getProducts();

  }
  onSortSelected(sort:string){
    this.shopParams.sort = sort;
    this.getProducts();
  }
  
  onPageChange(event:any){
    if (this.shopParams.pageNumber !== event){
      this.shopParams.pageNumber=event;
      this.getProducts();
    }
  }
  onSearch(){
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1; 
    this.getProducts();
  }
  onReset(){
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }
 
}
