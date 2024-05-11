import { configureStore } from "@reduxjs/toolkit";
import { MembersSlice } from "./Members.slice";

export const store = configureStore({
  reducer: {
    members: MembersSlice.reducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;
