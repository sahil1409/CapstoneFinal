import { AppBar, Badge, Box, createTheme, IconButton, List, ListItem, ThemeProvider, Toolbar, Typography } from "@mui/material";
import LocalHospitalIcon from '@mui/icons-material/LocalHospital';
import { Link, NavLink } from "react-router-dom";
import { ShoppingCart } from "@mui/icons-material";
import { useStoreContext } from "./Context";

const darkTheme = createTheme({
    palette: {
        mode: 'dark',
    },
});

const rightLinks = [
    { title: 'INVENTORY', path: '/inventory' },
]

const navStyles = {
    color: 'inherit', textDecoration: 'none', typography: 'h6',
    '&:hover': {
        color: '#b39ddb'
    },
    '&.active': {
        color: '#81d4fa'
    }
}

export default function Navbar() {

    const { cart } = useStoreContext();
    const medicineCount = cart?.items.reduce((sum, item) => sum + item.quantity, 0)

    return (
        <ThemeProvider theme={darkTheme}>
            <AppBar position="static" sx={{ mb: 4 }}>
                <Toolbar sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>

                    <Box display='flex' alignItems='center'>
                        <LocalHospitalIcon fontSize="large" />
                        <Typography variant="h6" marginLeft={1} component={NavLink} end to='/homepage' sx={navStyles} >
                            ABC Healthcare
                        </Typography>
                    </Box>



                    <Box display='flex' alignItems='center'>

                        <List sx={{ display: 'flex' }}>
                            {rightLinks.map(({ title, path }) => (
                                <ListItem
                                    component={NavLink}
                                    to={path}
                                    key={path}
                                    sx={navStyles}
                                >
                                    {title}
                                </ListItem>
                            ))}
                        </List>

                        <IconButton component={Link} to='/cart' size='large' sx={navStyles}>
                            <Badge badgeContent={medicineCount} color='primary'>
                                <ShoppingCart />
                            </Badge>
                        </IconButton>

                    </Box>

                </Toolbar>
            </AppBar>
        </ThemeProvider >
    )
}