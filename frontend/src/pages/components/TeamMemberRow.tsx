import { Member } from "api/types";
import React, { MouseEvent, useState } from "react";
import { useActivateMember, useDeactivateMember } from "api/members-service";
import { IconButton, Menu, MenuItem, TableCell, TableRow } from "@mui/material";
import { MoreVert } from "@mui/icons-material";
import { useDispatch } from "react-redux";
import { setRefetch } from "store/Members.slice";

interface TeamMemberRowProps {
  member: Member;
  handleEditMember: (id: string) => void;
}

export const TeamMemberRow = ({
  member,
  handleEditMember,
}: TeamMemberRowProps) => {
  const [menuOpen, setMenuOpen] = useState(false);
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const { postData: ActivateMember } = useActivateMember(member.id);
  const { postData: DeactivateMember } = useDeactivateMember(member.id);
  const dispatch = useDispatch();

  const handleMenuClose = () => {
    setMenuOpen(false);
  };

  const handleMenuOpen = (event: MouseEvent<HTMLButtonElement>) => {
    setMenuOpen(true);
    setAnchorEl(event.currentTarget);
  };

  const handleActivateMemberClick = async () => {
    await ActivateMember();
    dispatch(setRefetch(true));
    setMenuOpen(false);
  };

  const handleDeactivateMemberClick = async () => {
    await DeactivateMember();
    dispatch(setRefetch(true));
    setMenuOpen(false);
  };

  return (
    <TableRow>
      <TableCell
        component={"th"}
        scope={"row"}
        onClick={() => handleEditMember(member.id)}
      >
        {`${member.firstName} ${member.lastName}`}
      </TableCell>
      <TableCell>{member.email}</TableCell>
      <TableCell>{member.phoneNumber}</TableCell>
      <TableCell>{member.status}</TableCell>
      <TableCell>{member?.createdAt?.toString()}</TableCell>
      <TableCell>
        <IconButton onClick={handleMenuOpen}>
          <MoreVert />
        </IconButton>
        <Menu open={menuOpen} onClose={handleMenuClose} anchorEl={anchorEl}>
          {member.status === "Active" ? (
            <MenuItem onClick={handleDeactivateMemberClick}>Zablokuj</MenuItem>
          ) : (
            <MenuItem onClick={handleActivateMemberClick}>Odblokuj</MenuItem>
          )}
        </Menu>
      </TableCell>
    </TableRow>
  );
};
