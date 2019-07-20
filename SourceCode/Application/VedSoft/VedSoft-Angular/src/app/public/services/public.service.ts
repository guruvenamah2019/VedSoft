import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from "../../core/services/index"

@Injectable({ providedIn: 'root' })
export class PublicService {
    constructor(private http: HttpClient, private userService:UserService) { 


    }
    
    public login(){

        
    }
}