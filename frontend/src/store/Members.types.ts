import { Member } from "api/types";

export interface MembersSliceState {
  members: Member[];
  loading: boolean;
  refetch: boolean;
}

export type AddNewMemberPayload = {
  payload: { member: Member };
  type: string;
};
