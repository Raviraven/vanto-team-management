import { useGetTeamMembers } from "api/teams-service";
import { TempConst } from "TempConst";
import React, { useCallback, useEffect, useState } from "react";
import {
  Grid,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";
import { TeamDetailsHeader } from "./components/TeamDetailsHeader";
import { EditTeamMemberModal } from "./components/EditTeamMemberModal";
import { TeamMemberRow } from "./components/TeamMemberRow";
import { useMembers, useRefetchMembers } from "../store/selectors";
import { useDispatch } from "react-redux";
import { setMembers, setRefetch } from "../store/Members.slice";

export const TeamDetails = () => {
  const [editMemberModalOpened, setEditMemberModalOpened] = useState(false);
  const [memberIdToEdit, setMemberIdToEdit] = useState<string>("");
  const { fetchData, loading, data } = useGetTeamMembers(
    TempConst.HardcodedTeamId,
  );
  const teamMembers = useMembers();
  const refetchMembers = useRefetchMembers();
  const dispatch = useDispatch();

  const handleEditMember = useCallback((memberId: string) => {
    setMemberIdToEdit(memberId);
    setEditMemberModalOpened(true);
  }, []);

  useEffect(() => {
    if (!loading && data) {
      dispatch(setMembers(data));
    }
  }, [data, dispatch, loading]);

  useEffect(() => {
    if (refetchMembers) {
      void fetchData();
      dispatch(setRefetch(false));
    }
  }, [dispatch, fetchData, refetchMembers]);

  return (
    <>
      <Grid container flexDirection={"column"}>
        <Grid item>
          <TeamDetailsHeader teamId={TempConst.HardcodedTeamId} />
        </Grid>

        <Grid item>
          <TableContainer component={Paper}>
            <Table>
              <TableHead>
                <TableRow>
                  <TableCell>Nazwa</TableCell>
                  <TableCell>Adres email</TableCell>
                  <TableCell>Number telefonu</TableCell>
                  <TableCell>Status</TableCell>
                  <TableCell>Data utworzenia</TableCell>
                  <TableCell>Akcje</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {teamMembers.map((member, i) => (
                  <TeamMemberRow
                    key={`${member.firstName}${member.lastName}-${i}`}
                    member={member}
                    handleEditMember={handleEditMember}
                  />
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        </Grid>
      </Grid>

      {editMemberModalOpened && (
        <EditTeamMemberModal
          memberId={memberIdToEdit}
          open={editMemberModalOpened}
          setOpen={setEditMemberModalOpened}
        />
      )}
    </>
  );
};
