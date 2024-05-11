import { axiosInstance } from "./axios";
import { Member } from "./types";
import { useApiGet, useApiPost, useApiPut } from "./base-hook";

const urlPrefix = "members";

export const useGetMemberDetails = (id: string) => {
  return useApiGet<Member>(`${urlPrefix}/${id}`);
};

export const useActivateMember = (id: string) => {
  return useApiPost<Member>(`${urlPrefix}/${id}/activate`);
};

export const useDeactivateMember = (id: string) => {
  return useApiPost<Member>(`${urlPrefix}/${id}/deactivate`);
};

export const useUpdateMember = (id: string) => {
  return useApiPut<Member>(`${urlPrefix}/${id}/update`);
};
