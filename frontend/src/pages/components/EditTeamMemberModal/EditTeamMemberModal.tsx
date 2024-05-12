import { Member } from "api/types";
import { Box, Chip, Grid } from "@mui/material";
import { useForm } from "react-hook-form";
import { useGetMemberDetails, useUpdateMember } from "api/members-service";
import React, { useEffect } from "react";
import { ToggleInputFormField } from "components/form/ToggleInputFormField";
import { useDispatch } from "react-redux";
import { setRefetch } from "store/Members.slice";
import {
  DisplayLabelTypography,
  DisplayValueTypography,
} from "components/Common.styled";
import {
  FormContainer,
  EditMemberModal,
  ModalContent,
  Title,
  FormAvatarContainer,
  FormDetailsContainer,
  ButtonContainer,
  CloseButton,
} from "./EditTeamMemberModal.styled";

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
    <EditMemberModal open={open} onClose={handleClose}>
      <ModalContent container>
        <Grid item>
          <Title variant={"h6"}>
            {getValues().firstName} {getValues().lastName}
          </Title>
        </Grid>

        <FormContainer item>
          <FormAvatarContainer>
            avatar
            <Chip
              label={getValues().status === "Active" ? "Aktywny" : "Blokada"}
              color={getValues().status === "Active" ? "success" : "error"}
            />
          </FormAvatarContainer>

          <FormDetailsContainer>
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
              <DisplayLabelTypography>Data utworzenia</DisplayLabelTypography>
              <DisplayValueTypography>
                {getValues().createdAt?.toString()}
              </DisplayValueTypography>
            </Box>
          </FormDetailsContainer>
        </FormContainer>

        <ButtonContainer item>
          <CloseButton onClick={handleClose}>Zamknij</CloseButton>
        </ButtonContainer>
      </ModalContent>
    </EditMemberModal>
  );
};
