export class SubjectHiearchyModel {
    name?: string;
    id?: number;
    parentId?:number;
    userId?:number;
    hierarchyLevel?:number;
    parent?:SubjectHiearchyModel
    constructor() {

    };
}