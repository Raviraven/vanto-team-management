import { MembersSliceState } from "./Members.types";
import { createSlice } from "@reduxjs/toolkit";

const initialState: MembersSliceState = {
  loading: false,
  refetch: false,
  members: [],
};

export const MembersSlice = createSlice({
  name: "members",
  initialState,
  reducers: {
    setMembers: (state, action) => {
      state.members = action.payload;
    },
    setLoading: (state, action) => {
      state.loading = action.payload;
    },
    setRefetch: (state, action) => {
      state.refetch = action.payload;
    },
  },
});

export const { setMembers, setLoading, setRefetch } = MembersSlice.actions;
