import { SubjectHiearchyModel } from './subject-hiearchy.model';

export class CourseModel {
    name?: string;
    id?: number;
    courseDescription?: string;
    parentId?: number;
    userId?: number;
    duration?: number;
    durationUOM?: number;
    courseCost?: number;
    subjects?: SubjectHiearchyModel[];
    customerSubjectHiearchyIdList?:number[];
    constructor() {
    }
}
