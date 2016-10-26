import { Comment } from '../classes/comment';

export interface IPost {
  Id: number;
  UserName: string;
  PublishDate: string;
  Image: string;
  Title: string;
  Text: string;
  Tags: string[];
  LikesCount: number;
  Comments: Comment[];
  ShowComments: boolean;
}

export class Post implements IPost {
   Id: number;
   UserName: string;
   PublishDate: string;
   Image: string;
   Title: string;
   Text: string;
   Tags: string[];
   LikesCount: number;
   Comments: Comment[];
   ShowComments: boolean;

  constructor(title: string, text: string, user: string) {
      this.Id = 0;
      this.PublishDate = "Saturday, June 13, 2015 11:19 PM";
      this.Image = "content/images/female-1.png";
      this.Tags = ["tag 1", "tag 2"];
      this.Title = title;
      this.Text = text;
      this.UserName = user;
      this.LikesCount = 12;
      this.Comments = [];
  }
}