export interface Member {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  createdAt: Date;
  status: string;
  phoneNumber: string;
}

export type MemberUpdate = Omit<Member, "id">;

export interface RandomUserResponse {
  results: RandomUser[];
}

interface RandomUser {
  name: {
    first: string;
    last: string;
  };
  email: string;
  registered: {
    date: Date;
  };
  phone: string;
  picture: {
    thumbnail: string;
  };
}

export interface CreateTeamMember {
  teamId: string;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
}

export interface EditMember {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  createdAt: Date;
  status: string;
  phoneNumber: string;
}
