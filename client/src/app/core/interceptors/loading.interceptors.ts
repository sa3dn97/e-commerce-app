import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { delay, finalize } from "rxjs/operators";
import { LoadingService } from "../services/loading.service";


@Injectable()
 export class LoadingInterceptors implements HttpInterceptor{
     constructor(private busyService:LoadingService){}
     intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
         if(!req.url.includes('emailexists')){
            this.busyService.loading();
         }
         return next.handle(req).pipe(
            delay(1000),
            finalize(()=> {
                this.busyService.idle();
            })
            
            );
     }
    }