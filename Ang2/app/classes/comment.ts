export interface IComment {
  id: number;
  PostId: number;
  UserName: string;
  PublishDate: string;
  Image: string;
  Text: string;
}

export class Comment implements IComment {
   id: number;
   PostId: number;
   UserName: string;
   PublishDate: string;
   Image: string;
   Text: string;

  constructor() {

  }
}