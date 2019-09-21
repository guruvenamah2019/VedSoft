import { Component, OnInit,Output,EventEmitter, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { AddressModel } from 'src/app/core/models/master-model';


@Component({
    templateUrl: 'address-form.component.html',
    selector:'ved-address'
})

export class AddressComponent implements OnInit {
  @Output()
	private formReady : EventEmitter<FormGroup> = new EventEmitter<FormGroup>();
  private form: FormGroup; 
  
  @Input("submitted")
  private submitted:boolean;
  @Input("model")
  private address:AddressModel;

	constructor(private fb: FormBuilder) {
		this.form = this.fb.group({
			"name": new FormControl( this.address!=null? this.address.name:"", Validators.required),
			"address1": new FormControl(this.address!=null? this.address.address1:""),
			"address2": new FormControl(this.address!=null? this.address.address2:""),
			"city": new FormControl(this.address!=null? this.address.city:"", Validators.required),
			"state": new FormControl(this.address!=null? this.address.state:"", [Validators.required]),
			"zipcode": new FormControl(this.address!=null? this.address.zipcode:"", [Validators.required]),
			"country": new FormControl(this.address!=null? this.address.country:"", [Validators.required])
		});
	}

	ngOnInit(): void {
		this.formReady.emit(this.form);
  }
  
  get f() { return this.form.controls; }
      
}