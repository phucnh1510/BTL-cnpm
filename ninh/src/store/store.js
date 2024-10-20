import { writable } from "svelte/store"

export const accessTokenStore = writable({})
export const problemsListStore = writable([])
export const submitCodeStore = writable({})
export const editorContent = writable('');
export const editorLanguage = writable(0);

export const resultData = writable(null); // Changed to resultData // New store for the API response data-