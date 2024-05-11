import { Member } from "./types";
import { useApiGet, useApiPost } from "./base-hook";

const urlPrefix = "teams";

export const useGetTeamMembers = (id: string) => {
  return useApiGet<Member[]>(`${urlPrefix}/${id}/members`);
};

export const useCreateTeamMember = (teamId: string) => {
  return useApiPost(`${urlPrefix}/${teamId}/members`);
};
