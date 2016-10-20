export interface IComment {
  Id: number;
  PostId: number;
  UserName: string;
  PublishDate: string;
  Image: string;
  Text: string;
}

export class Comment implements IComment {
   Id: number;
   PostId: number;
   UserName: string;
   PublishDate: string;
   Image: string;
   Text: string;

  constructor() {

  }
}