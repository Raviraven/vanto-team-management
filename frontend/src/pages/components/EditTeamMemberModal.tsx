import { Member } from "api/types";
import { Box, Button, Grid, Modal, Typography } from "@mui/material";
import { useForm } from "react-hook-form";
import { useGetMemberDetails, useUpdateMember } from "api/members-service";
import React, { useEffect } from "react";
import { ToggleInputFormField } from "components/form/ToggleInputFormField";
import { useDispatch } from "react-redux";
import { setRefetch } from "store/Members.slice";

interface EditTeamMemberModalProps {
  memberId: string;
  open: boolean;
  setOpen: (value: boolean) => void;
}

export const EditTeamMemberModal = (props: EditTeamMemberModalProps) => {
  const { memberId, open, setOpen } = props;
  const { handleSubmit, control, getValues, reset, setValue } = useForm<Member>(
    {
      defaultValues: {
        id: memberId,
        firstName: "",
        lastName: "",
        email: "",
        phoneNumber: "",
        status: "",
        createdAt: null!,
      },
    },
  );
  const dispatch = useDispatch();

  const { loading: isMemberDetailsLoading, data: memberDetails } =
    useGetMemberDetails(memberId);

  const { putData: UpdateMemberApi } = useUpdateMember(memberId);

  const handleClose = () => {
    setOpen(false);
    reset();
  };

  const handleUpdateMember = async (data: Member) => {
    await UpdateMemberApi(data);
    dispatch(setRefetch(true));
  };

  useEffect(() => {
    if (isMemberDetailsLoading || !memberDetails) {
      return;
    }

    setValue("firstName", memberDetails.firstName);
    setValue("lastName", memberDetails.lastName);
    setValue("email", memberDetails.email);
    setValue("phoneNumber", memberDetails.phoneNumber);
    setValue("status", memberDetails.status);
    setValue("createdAt", memberDetails.createdAt);
  }, [isMemberDetailsLoading, memberDetails, setValue]);

  return (
    <Modal open={open} onClose={handleClose}>
      <Grid
        container
        flexDirection={"column"}
        sx={{ backgroundColor: "#FCFCFC" }}
      >
        <Grid item>
          <Typography variant={"h6"}>
            {getValues().firstName} {getValues().lastName}
          </Typography>
        </Grid>

        <Grid item display={"grid"} gridTemplateColumns={"100px 1fr"}>
          <Box>
            avatar <br />
            {getValues().status}
          </Box>

          <Box sx={{ display: "flex", flexDirection: "column", width: "100%" }}>
            <ToggleInputFormField
              name={"firstName"}
              label={"Nazwa"}
              control={control}
              getValues={getValues}
              handleSubmit={handleSubmit(handleUpdateMember)}
            />

            <ToggleInputFormField
              name={"lastName"}
              label={"Nazwisko"}
              control={control}
              getValues={getValues}
              handleSubmit={handleSubmit(handleUpdateMember)}
            />

            <ToggleInputFormField
              name={"email"}
              label={"Adres email"}
              control={control}
              getValues={getValues}
              handleSubmit={handleSubmit(handleUpdateMember)}
            />

            <ToggleInputFormField
              name={"phoneNumber"}
              label={"Numer telefonu"}
              control={control}
              getValues={getValues}
              handleSubmit={handleSubmit(handleUpdateMember)}
            />

            <Box>
              <Typography variant={"body2"}>Data utworzenia</Typography>
              <Typography variant={"body1"}>
                {getValues().createdAt?.toString()}
              </Typography>
            </Box>
          </Box>
        </Grid>

        <Grid item>
          <Button onClick={handleClose}>Zamknij</Button>
        </Grid>
      </Grid>
    </Modal>
  );
};
