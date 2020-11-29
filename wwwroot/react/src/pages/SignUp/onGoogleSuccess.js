import axios from 'axios';
import { 
	PAGE_DOMAIN,
	PAGE_REGISTER,
	PAGE_SIGN_IN, 
} from 'consts/page.js';

let timeout;
const onGoogleSuccess = (e, setState) => {
	const { 
		email, 
		givenName: firstName, 
		familyName: secondName, 
	} = e.profileObj;
	const {
		id_token,
		access_token,
		login_hint,
		token_type,
		expires_at,
		expires_in,
	} = e.tokenObj;
	const googleId = e.googleId;

	setState(true);
	clearTimeout(timeout);
	timeout = setTimeout(async () => {
		try {
			await axios.post(PAGE_DOMAIN + PAGE_REGISTER, {
				register_service_id: 1,
				email,
				first_name: firstName,
				second_name: secondName,
				googleId,
				id_token,
				access_token,
				login_hint,
				token_type,
				expires_at,
				expires_in,
			});
			window.location.href = PAGE_SIGN_IN;
		}
		catch (err) {
			setState(false);
			alert('Ошибка: '+ err.message);
		}
	}, 0);
};

export default onGoogleSuccess;
