import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { BaseService,  StudentService } from 'src/app/core/services';
import { RequestModel } from 'src/app/core/models/shared-model';
import { CommonConstants } from 'src/app/core/enums';
import { StudentModel } from 'src/app/core/models/student-model/student-master.model';



@Component({
    templateUrl: 'student-list.component.html',
})

export class StudentListComponent implements OnInit {

    level: number = 1;
    bsModalRef: BsModalRef;
    studentList: StudentModel[] = [];
    constructor(private route: ActivatedRoute, private studentService: StudentService, private baseService: BaseService) {
            this.route.parent.params.subscribe(params => console.log(params)); // Object {artistId: 12345}

    }
    ngOnInit() {
        this.getStudentList();
    }



    getStudentList() {
        let student: StudentModel = new StudentModel();
        let searchInput = this.baseService.getSearchRequestModel(student);
        searchInput.pageNumber = 1;
        searchInput.pageSize = 100;

        this.studentService.getStudent(searchInput).subscribe(x => {
            if (x != null) {
                this.studentList = x;
            }
        })


    }

    
    
    

}