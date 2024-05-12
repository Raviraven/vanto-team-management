import { Box, Button, Grid, Modal, styled, Typography } from "@mui/material";

export const EditMemberModal = styled(Modal)({
  display: "flex",
  justifyContent: "center",
  alignItems: "center",
});

export const ModalContent = styled(Grid)({
  backgroundColor: "#FCFCFC",
  width: "480px",
  padding: "16px",
  borderRadius: "8px",
  flexDirection: "column",
});

export const Title = styled(Typography)({
  fontSize: "18px",
  fontWeight: 600,
  lineHeight: "21.78px",
  color: "#201D20",
});

export const FormContainer = styled(Grid)({
  marginTop: "16px",
  display: "grid",
  gridTemplateColumns: "158px 1fr",
  gap: "16px",
});

export const FormAvatarContainer = styled(Box)({
  display: "flex",
  flexDirection: "column",
  alignItems: "center",
  justifyContent: "center",
  width: "100%",
});

export const FormDetailsContainer = styled(Box)({
  display: "flex",
  flexDirection: "column",
  width: "100%",
});

export const ButtonContainer = styled(Grid)({
  marginTop: "32px",
  display: "flex",
  justifyContent: "center",
  width: "100%",
});

export const CloseButton = styled(Button)({
  width: "100%",
  height: "29px",
  borderRadius: "8px",
  fontSize: "14px",
  fontWeight: "600",
  lineHeight: "16.94px",
  padding: "6px 18px",
  border: "solid 1px #CFC9CF",
  color: "#201D20",
});
