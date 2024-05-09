import {axiosInstance} from "./axios";
import {Member, MemberUpdate} from "./types";

const urlPrefix = 'members';

export const GetMemberDetails = async (id: string) => {
    const result = await axiosInstance.get<Member>(`${urlPrefix}/${id}`);
    return result.data;
}

export const ActivateMember = async (id: string) => {
    const result = await axiosInstance.post<Member>(`${urlPrefix}/${id}/activate`);
    return result.data;
}

export const DeactivateMember = async (id: string) => {
    const result = await axiosInstance.post<Member>(`${urlPrefix}/${id}/deactivate`);
    return result.data;
}

export const UpdateMember = async (data: Member) => {
    const result = await axiosInstance.put<Member>(`${urlPrefix}/${data.id}/update`, data);
    return result.data;
}