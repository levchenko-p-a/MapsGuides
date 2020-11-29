import React from 'react';
import { Link } from 'react-router-dom';
import Box from '@material-ui/core/Box';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import TextField from '@material-ui/core/TextField';
import { PAGE_MAP } from 'consts/page.js';
import onSubmit from './onSubmit.js';

let Payment = () => {
	const [ state, setState ] = React.useState(() => ({
		load: false,
		ready: false,
	}));
	const _onSubmit = React.useCallback((e) => onSubmit(e, setState), [
		setState,
	]);

	return <React.Fragment>
		{state.load
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
			{state.ready
				? <Box
					align="center">
					<Typography variant="h5">
						Оплата прошла успешно
					</Typography>
					<Box mt={2} />
					<Button
						variant="outlined" 
						color="primary"
						component={Link}
						to={PAGE_MAP}>
						Вернуться на карту
					</Button>
				</Box>
				: <React.Fragment>
					<Typography variant="h5">
						Оплата - <b>5.99$</b>
					</Typography>
					<form onSubmit={_onSubmit}>
						<Box my={2}>
							<FormControl 
								fullWidth
								required
								variant="outlined">
								<InputLabel id="select-label-card">
									Тип оплаты  
								</InputLabel>
								<Select
									labelId="select-label-card"
									id="select-card"
									name="card"
									label="Тип карты"
									defaultValue={1}
									onChange={() => {}}>
									<MenuItem value={1}>
										Visa, MasterCard
									</MenuItem>
									<MenuItem value={2}>
										PayPal
									</MenuItem>
									<MenuItem value={3}>
										LiqPay
									</MenuItem>
								</Select>
							</FormControl>
						</Box>
						<Box my={2}>
							<TextField
								fullWidth
								label="Промокод"
								name="promocode"
								type="text"
								variant="outlined" />
						</Box>
						<Button
							variant="outlined" 
							color="primary"
							type="submit">
							Оплатить
						</Button>
					</form>
				</React.Fragment>}
		</Box>
	</React.Fragment>;
};

Payment = React.memo(Payment);

export default Payment;
