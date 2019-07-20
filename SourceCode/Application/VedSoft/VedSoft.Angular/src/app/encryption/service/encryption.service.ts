import { Injectable } from "@angular/core";
import { EncryptionModel } from '../models/encryption.model';
import * as CryptoJS from 'crypto-js';



@Injectable()
export class EncryptionService {

    constructor() {
    }

    EncryptionSHA1(text: string):string {
        var hash = CryptoJS.SHA1(text);
        return hash.toString();
    }

   
}