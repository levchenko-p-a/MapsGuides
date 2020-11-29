
export default [{
	id: 1,
	name: 'Пароль',
	entity_id: 1,
	type_id: 10,
	source_id: 4,
}, {
	id: 2,
	name: 'Email',
	entity_id: 1,
	type_id: 6,
	source_id: 4,
}, {
	id: 3,
	name: 'Найти пользователя',
	entity_id: 2,
	props: [{
		id: 2,
		entity_id: 1,
	}],
}, {
	id: 4,
	name: 'Авторизовать пользователя по нужному паролю',
	entity_id: 2,
	props: [{
		id: 1,
		entity_id: 1,
	}, {
		id: 3,
		entity_id: 2,
	}],
}];
