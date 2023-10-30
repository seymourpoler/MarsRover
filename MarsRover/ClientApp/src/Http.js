export function createHttp() {
    
    var get = async (url) => {
        const response = await fetch(url);
        return buildResultFrom(response);
    };

    var post = async (url, entity) => {
        const response = await fetch(url, {
            method: 'POST',
            cache: 'no-cache',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(entity)
        });
        return await buildResultFrom(response);
    }  

    async function buildResultFrom(response) {
        const body = await buildBody(response);
        return {
            statusCode: response.status,
            body
        }
    }

    async function buildBody(response) {
        try {
            return await response.json();
        } catch {
            return {};
        }
    }

    return {
        get: get,
        post: post,
    };
}