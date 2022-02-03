import { Photo } from "./photo";



type GUID = string & {isGuid:true};
function guid(guid:string):GUID {
    return guid as GUID;
}
export interface Member{
    id: GUID;
    username:string;
    photoUrl:string;
    age: number;
    knownAs: string;
    created: Date;
    lastActive:Date;
    gender:string;
    introduction:string;
    lookingFor:string;
    interests:string;
    city:string;
    country:string;
    photos: Photo[];
}
