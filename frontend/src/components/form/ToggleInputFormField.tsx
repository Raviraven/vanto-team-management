import { InputFormField } from "./InputFormField";
import React, { useState } from "react";
import { Box, IconButton, Typography } from "@mui/material";
import { Member } from "api/types";
import { UseFormGetValues } from "react-hook-form";
import {
  CloseOutlined,
  DoneOutline,
  ModeEditOutline,
} from "@mui/icons-material";

interface ToggleInputFormFieldProps {
  name: "firstName" | "lastName" | "email" | "phoneNumber" | "status";
  label: string;
  control: any;
  handleSubmit: () => Promise<void>;
  getValues: UseFormGetValues<Member>;
}

export const ToggleInputFormField = (props: ToggleInputFormFieldProps) => {
  const { name, label, control, getValues, handleSubmit } = props;
  const [edit, setEdit] = useState(false);

  const handleEdit = () => {
    setEdit(true);
  };

  const handleCancel = () => {
    setEdit(false);
  };

  const handleSave = async () => {
    await handleSubmit();
    setEdit(false);
  };

  return edit ? (
    <Box>
      <InputFormField name={name} label={label} control={control} />
      <IconButton onClick={handleSave}>
        <DoneOutline />
      </IconButton>
      <IconButton onClick={handleCancel}>
        <CloseOutlined />
      </IconButton>
    </Box>
  ) : (
    <Box>
      <Box>
        <Typography variant={"body2"}>{label}</Typography>
        <Typography variant={"body1"}>{getValues(name)}</Typography>
      </Box>
      <Box>
        <IconButton onClick={handleEdit}>
          <ModeEditOutline />
        </IconButton>
      </Box>
    </Box>
  );
};
