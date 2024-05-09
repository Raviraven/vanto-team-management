import { axiosInstance } from "./axios";
import { CreateTeamMember, Member } from "./types";

const urlPrefix = "teams";

export const GetTeamMembers = async (id: string) => {
  const result = await axiosInstance.get<Member[]>(
    `${urlPrefix}/${id}/members`,
  );
  return result.data;
};

export const CreateNewTeamMember = async (
  teamId: string,
  data: CreateTeamMember,
) => {
  const result = await axiosInstance.post(
    `${urlPrefix}/${teamId}/members`,
    data,
  );
  return result.data;
};
