export class CourseHiearchyModel {
    name?: string;
    id?: number;
    parentId?:number;
    userId?:number;
    hierarchyLevel?:number;
    parent?:CourseHiearchyModel
    constructor() {

    };
}