type GUID = string & {isGuid:true};
function guid(guid:string):GUID {
    return guid as GUID;
}

export interface Message{
    id: GUID;
    senderId: number;
    senderUsername: string;
    senderPhotoUrl: string;
    recipientId: GUID;
    recipientUsername: string;
    recipientPhotoUrl: string;
    content: string;
    dateRead?: Date;
    messageSent: Date;
}