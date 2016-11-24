export interface IUserProfile {
  username: string;
  password: string;
  Id: string;
  Email: string;
  FirstName: string;
  LastName: string;
  Gender: string;
  Age: number;
  Image: string;
}

export class UserProfile implements IUserProfile {
  username: string;
  password: string;
  Id: string;
  Email: string;
  FirstName: string;
  LastName: string;
  Gender: string;
  Age: number;
  Image: string;

  constructor() {
  }
}