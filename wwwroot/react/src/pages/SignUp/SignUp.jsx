import React from 'react';
import GoogleLogin from 'react-google-login';
import Box from '@material-ui/core/Box';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import onSubmit from './onSubmit.js';
import onGoogleSuccess from './onGoogleSuccess.js';
import onGoogleFailure from './onGoogleFailure.js';

let SignUp = () => {
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
				Регистрация
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
						label="Телефон"
						name="phone"
						type="phone"
						variant="outlined" />
				</Box>
				<Box my={2}>
					<TextField
						fullWidth
						label="Имя"
						name="first_name"
						type="text"
						variant="outlined" />
				</Box>
				<Box my={2}>
					<TextField
						fullWidth
						label="Фамилия"
						name="second_name"
						type="text"
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
				<Box my={2}>
					<TextField
						fullWidth
						required
						label="Подтверждение пароля"
						name="password_confirm"
						type="password"
						variant="outlined" />
				</Box>
				<Button
					variant="outlined" 
					color="primary"
					type="submit">
					Далее
				</Button>
			</form>
			<Box
				align="center">
				<GoogleLogin
					clientId="575355600202-ht4mn06qh6g4qktmu7htjgm7vei9m5t1.apps.googleusercontent.com"
					buttonText="Login"
					onSuccess={_onGoogleSuccess}
					onFailure={_onGoogleFailure}
					cookiePolicy={'single_host_origin'} />
			</Box>
		</Box>
	</React.Fragment>;
};

SignUp = React.memo(SignUp);

export default SignUp;
