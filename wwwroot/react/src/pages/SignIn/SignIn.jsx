import React from 'react';
import GoogleLogin from 'react-google-login';
import Box from '@material-ui/core/Box';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import { CONF_GOOGLE_CLIENT_ID } from 'consts/config.js';
import onSubmit from './onSubmit.js';
import onGoogleSuccess from './onGoogleSuccess.js';
import onGoogleFailure from './onGoogleFailure.js';

let SignIn = () => {
	const [ load, setLoad ] = React.useState(() => false);
	const _onSubmit = React.useCallback((e) => onSubmit(e, setLoad), [
		setLoad,
	]);
	const _onGoogleSuccess = React.useCallback((e) => onGoogleSuccess(e, setLoad), [
		setLoad,
	]);
	const _onGoogleFailure = React.useCallback((e) => onGoogleFailure(e, setLoad), [
		setLoad,
	]);

	return <React.Fragment>
		{load
			? <Box
				position="fixed"
				top="0px"
				left="0px"
				width="100%"
				height="100%"
				zIndex="2"
				style={{
					backgroundColor: 'rgba(255, 255, 255, .6)'
				}} />
			: <React.Fragment />}
		<Box
			px={8} 
			py={4}>
			<Typography variant="h5">
				Вход
			</Typography>
			<form onSubmit={_onSubmit}>
				<Box my={2}>
					<TextField
						fullWidth
						required
						label="Email"
						name="email"
						type="email"
						variant="outlined" />
				</Box>
				<Box my={2}>
					<TextField
						fullWidth
						required
						label="Пароль"
						name="password"
						type="password"
						variant="outlined" />
				</Box>
				<Button
					variant="outlined" 
					color="primary"
					type="submit">
					Войти
				</Button>
			</form>
			<Box
				align="center">
				<GoogleLogin
					clientId={CONF_GOOGLE_CLIENT_ID}
					buttonText="Login"
					onSuccess={_onGoogleSuccess}
					onFailure={_onGoogleFailure}
					cookiePolicy={'single_host_origin'} />
			</Box>
		</Box>
	</React.Fragment>;
};

SignIn = React.memo(SignIn);

export default SignIn;
