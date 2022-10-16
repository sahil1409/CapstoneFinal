import { Paper, Typography, Box, TextField, Container, Button } from "@mui/material";
import { useForm } from "react-hook-form";
import { Link } from "react-router-dom";

export default function Login() {

    const { register, formState: {errors, isValid}} = useForm({
        mode: 'all'
    })

    return (
        <Container component={Paper} maxWidth="sm" sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', p: 4 }}>
            <Typography component="h1" variant="h5">
                Log In
            </Typography>
            <Box component="form" noValidate sx={{ mt: 1 }}>
                <TextField
                    margin="normal"
                    fullWidth
                    label="Username"
                    autoFocus
                    {...register('username', { required: 'Username Required' })}
                    error={!!errors.username}
                />
                <TextField
                    margin="normal"
                    fullWidth
                    label="Password"
                    type="password"
                    {...register('password', { required: 'Password Required' })}
                    error={!!errors.username}
                />
                <Button
                    disabled={!isValid}
                    component={Link}
                    to='/homepage'
                    fullWidth
                    variant="contained"
                    sx={{ mt: 3 }}
                >
                    Log In
                </Button>
                <Button
                    component={Link}
                    to='/register'
                    fullWidth
                    variant="contained"
                    sx={{ mt: 3, mb: 2, '&:hover': { color: 'white' }, }}
                >
                    Register
                </Button>
            </Box>
        </Container>
    )
}