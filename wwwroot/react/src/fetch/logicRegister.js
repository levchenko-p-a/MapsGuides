
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
	name: 'Сгенерировать ключ для верификации по Email',
	entity_id: 2,
	props: [{
		id: 1,
		entity_id: 1,
	}, {
		id: 2,
		entity_id: 1,
	}],
}, {
	id: 4,
	name: 'Создать в базе нового пользователя',
	entity_id: 2,
	props: [{
		id: 1,
		entity_id: 1,
	}, {
		id: 2,
		entity_id: 1,
	}, {
		id: 3,
		entity_id: 2,
	}],
}, {
	id: 5,
	name: 'Отправить Email для верификации',
	entity_id: 2,
	props: [{
		id: 1,
		entity_id: 1,
	}, {
		id: 3,
		entity_id: 2,
	}],
}];
