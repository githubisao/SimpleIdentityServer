﻿using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using SimpleIdentityServer.Core.Errors;
using SimpleIdentityServer.Core.Exceptions;
using SimpleIdentityServer.Core.Helpers;
using SimpleIdentityServer.Core.Models;
using SimpleIdentityServer.Core.Parameters;
using SimpleIdentityServer.Core.Validators;

namespace SimpleIdentityServer.Core.UnitTests.Validators
{
    [TestFixture]
    public sealed class AuthorizationCodeGrantTypeParameterAuthEdpValidatorFixture
    {
        private Mock<IParameterParserHelper> _parameterParserHelperFake;

        private Mock<IClientValidator> _clientValidatorFake;

        private IAuthorizationCodeGrantTypeParameterAuthEdpValidator
            _authorizationCodeGrantTypeParameterAuthEdpValidator;

        [Test]
        public void When_Validating_Authorization_Parameter_With_Empty_Scope_Then_Exception_Is_Thrown()
        {
            // ARRANGE
            InitializeFakeObjects();
            const string state = "state";
            var authorizationParameter = new AuthorizationParameter
            {
                State =  state
            };

            // ACT & ASSERT
            var exception = Assert.Throws<IdentityServerExceptionWithState>(
                () => _authorizationCodeGrantTypeParameterAuthEdpValidator.Validate(authorizationParameter));
            Assert.IsTrue(exception.Code == ErrorCodes.InvalidRequestCode);
            Assert.IsTrue(exception.Message == string.Format(ErrorDescriptions.MissingParameter, Constants.StandardAuthorizationRequestParameterNames.ScopeName));
            Assert.IsTrue(exception.State == state);
        }
        
        [Test]
        public void When_Validating_Authorization_Parameter_With_Empty_ClientId_Then_Exception_Is_Thrown()
        {
            // ARRANGE
            InitializeFakeObjects();
            const string state = "state";
            var authorizationParameter = new AuthorizationParameter
            {
                State = state,
                Scope = "scope"
            };

            // ACT & ASSERT
            var exception = Assert.Throws<IdentityServerExceptionWithState>(
                () => _authorizationCodeGrantTypeParameterAuthEdpValidator.Validate(authorizationParameter));
            Assert.IsTrue(exception.Code == ErrorCodes.InvalidRequestCode);
            Assert.IsTrue(exception.Message == string.Format(ErrorDescriptions.MissingParameter, Constants.StandardAuthorizationRequestParameterNames.ClientIdName));
            Assert.IsTrue(exception.State == state);
        }

        [Test]
        public void When_Validating_Authorization_Parameter_With_Empty_RedirectUri_Then_Exception_Is_Thrown()
        {
            // ARRANGE
            InitializeFakeObjects();
            const string state = "state";
            var authorizationParameter = new AuthorizationParameter
            {
                State = state,
                Scope = "scope",
                ClientId = "clientId"
            };

            // ACT & ASSERT
            var exception = Assert.Throws<IdentityServerExceptionWithState>(
                () => _authorizationCodeGrantTypeParameterAuthEdpValidator.Validate(authorizationParameter));
            Assert.IsTrue(exception.Code == ErrorCodes.InvalidRequestCode);
            Assert.IsTrue(exception.Message == string.Format(ErrorDescriptions.MissingParameter, Constants.StandardAuthorizationRequestParameterNames.RedirectUriName));
            Assert.IsTrue(exception.State == state);
        }

        [Test]
        public void When_Validating_Authorization_Parameter_With_Empty_ResponseType_Then_Exception_Is_Thrown()
        {
            // ARRANGE
            InitializeFakeObjects();
            const string state = "state";
            var authorizationParameter = new AuthorizationParameter
            {
                State = state,
                Scope = "scope",
                ClientId = "clientId",
                RedirectUrl = "redirectUrl"
            };

            // ACT & ASSERT
            var exception = Assert.Throws<IdentityServerExceptionWithState>(
                () => _authorizationCodeGrantTypeParameterAuthEdpValidator.Validate(authorizationParameter));
            Assert.IsTrue(exception.Code == ErrorCodes.InvalidRequestCode);
            Assert.IsTrue(exception.Message == string.Format(ErrorDescriptions.MissingParameter, Constants.StandardAuthorizationRequestParameterNames.ResponseTypeName));
            Assert.IsTrue(exception.State == state);
        }

        [Test]
        public void When_Vadidating_Authorization_Parameter_With_InvalidResponseType_Then_Exception_Is_Thrown()
        {
            // ARRANGE
            InitializeFakeObjects();
            const string state = "state";
            var authorizationParameter = new AuthorizationParameter
            {
                State = state,
                Scope = "scope",
                ClientId = "clientId",
                RedirectUrl = "redirectUrl",
                ResponseType = "invalid_response_type"
            };

            // ACT & ASSERT
            var exception = Assert.Throws<IdentityServerExceptionWithState>(
                () => _authorizationCodeGrantTypeParameterAuthEdpValidator.Validate(authorizationParameter));
            Assert.IsTrue(exception.Code == ErrorCodes.InvalidRequestCode);
            Assert.IsTrue(exception.Message == ErrorDescriptions.AtLeastOneResponseTypeIsNotSupported);
            Assert.IsTrue(exception.State == state);
        }

        [Test]
        public void When_Validating_Authorization_Parameter_With_Invalid_Prompt_Then_Exception_Is_Thrown()
        {
            // ARRANGE
            InitializeFakeObjects();
            const string state = "state";
            var authorizationParameter = new AuthorizationParameter
            {
                State = state,
                Scope = "scope",
                ClientId = "clientId",
                RedirectUrl = "redirectUrl",
                ResponseType = "code",
                Prompt = "invalid_prompt"
            };

            // ACT & ASSERT
            var exception = Assert.Throws<IdentityServerExceptionWithState>(
                () => _authorizationCodeGrantTypeParameterAuthEdpValidator.Validate(authorizationParameter));
            Assert.IsTrue(exception.Code == ErrorCodes.InvalidRequestCode);
            Assert.IsTrue(exception.Message == ErrorDescriptions.AtLeastOnePromptIsNotSupported);
            Assert.IsTrue(exception.State == state);
        }

        [Test]
        public void When_Validating_Authorization_Parameter_With_NoneLoginPromptParameter_Then_Exception_Is_Thrown()
        {
            // ARRANGE
            InitializeFakeObjects();
            const string state = "state";
            var authorizationParameter = new AuthorizationParameter
            {
                State = state,
                Scope = "scope",
                ClientId = "clientId",
                RedirectUrl = "redirectUrl",
                ResponseType = "code",
                Prompt = "none login"
            };
            _parameterParserHelperFake.Setup(p => p.ParsePromptParameters(It.IsAny<string>()))
                .Returns(new List<PromptParameter>
                {
                    PromptParameter.none,
                    PromptParameter.login
                });

            // ACT & ASSERT
            var exception = Assert.Throws<IdentityServerExceptionWithState>(
                () => _authorizationCodeGrantTypeParameterAuthEdpValidator.Validate(authorizationParameter));
            Assert.IsTrue(exception.Code == ErrorCodes.InvalidRequestCode);
            Assert.IsTrue(exception.Message == ErrorDescriptions.PromptParameterShouldHaveOnlyNoneValue);
            Assert.IsTrue(exception.State == state);
        }

        [Test]
        public void When_Validating_Authorization_Parameter_With_Not_Well_Formed_Uri_Then_Exception_Is_Thrown()
        {
            // The redirect_uri is considered well-formed according to the RFC-3986
            // ARRANGE
            InitializeFakeObjects();
            const string state = "state";
            var authorizationParameter = new AuthorizationParameter
            {
                State = state,
                Scope = "scope",
                ClientId = "clientId",
                RedirectUrl = "not_well_formed_uri",
                ResponseType = "code",
                Prompt = "none"
            };
            _parameterParserHelperFake.Setup(p => p.ParsePromptParameters(It.IsAny<string>()))
                .Returns(new List<PromptParameter>
                {
                    PromptParameter.none
                });

            // ACT & ASSERT
            var exception = Assert.Throws<IdentityServerExceptionWithState>(
                () => _authorizationCodeGrantTypeParameterAuthEdpValidator.Validate(authorizationParameter));
            Assert.IsTrue(exception.Code == ErrorCodes.InvalidRequestCode);
            Assert.IsTrue(exception.Message == ErrorDescriptions.TheRedirectionUriIsNotWellFormed);
            Assert.IsTrue(exception.State == state);
        }

        [Test]
        public void When_Validating_Authorization_Parameter_With_Invalid_ClientId_Then_Exception_Is_Thrown()
        {
            // ARRANGE
            InitializeFakeObjects();
            const string state = "state";
            const string clientId = "clientId";
            var authorizationParameter = new AuthorizationParameter
            {
                State = state,
                Scope = "scope",
                ClientId = clientId,
                RedirectUrl = "http://localhost",
                ResponseType = "code",
                Prompt = "none"
            };
            _parameterParserHelperFake.Setup(p => p.ParsePromptParameters(It.IsAny<string>()))
                .Returns(new List<PromptParameter>
                {
                    PromptParameter.none
                });
            _clientValidatorFake.Setup(c => c.ValidateClientExist(It.IsAny<string>()))
                .Returns(() => null);

            // ACT & ASSERT
            var exception = Assert.Throws<IdentityServerExceptionWithState>(
                () => _authorizationCodeGrantTypeParameterAuthEdpValidator.Validate(authorizationParameter));
            Assert.IsTrue(exception.Code == ErrorCodes.InvalidRequestCode);
            Assert.IsTrue(exception.Message == string.Format(ErrorDescriptions.ClientIsNotValid, clientId));
            Assert.IsTrue(exception.State == state);
        }

        [Test]
        public void When_Validating_Authorization_Parameter_With_RedirectUri_Not_Known_By_The_Client_Then_Exception_Is_Thrown()
        {
            // ARRANGE
            InitializeFakeObjects();
            const string state = "state";
            const string clientId = "clientId";
            const string redirectUri = "http://localhost";
            var authorizationParameter = new AuthorizationParameter
            {
                State = state,
                Scope = "scope",
                ClientId = clientId,
                RedirectUrl = redirectUri,
                ResponseType = "code",
                Prompt = "none"
            };
            var client = new Client();
            _parameterParserHelperFake.Setup(p => p.ParsePromptParameters(It.IsAny<string>()))
                .Returns(new List<PromptParameter>
                {
                    PromptParameter.none
                });
            _clientValidatorFake.Setup(c => c.ValidateClientExist(It.IsAny<string>()))
                .Returns(client);
            _clientValidatorFake.Setup(c => c.ValidateRedirectionUrl(It.IsAny<string>(),
                It.IsAny<Client>()))
                .Returns(() => string.Empty);

            // ACT & ASSERT
            var exception = Assert.Throws<IdentityServerExceptionWithState>(
                () => _authorizationCodeGrantTypeParameterAuthEdpValidator.Validate(authorizationParameter));
            Assert.IsTrue(exception.Code == ErrorCodes.InvalidRequestCode);
            Assert.IsTrue(exception.Message == string.Format(ErrorDescriptions.RedirectUrlIsNotValid, redirectUri));
            Assert.IsTrue(exception.State == state);
        }

        private void InitializeFakeObjects()
        {
            _parameterParserHelperFake = new Mock<IParameterParserHelper>();
            _clientValidatorFake = new Mock<IClientValidator>();
            _authorizationCodeGrantTypeParameterAuthEdpValidator = new AuthorizationCodeGrantTypeParameterAuthEdpValidator(
                _parameterParserHelperFake.Object,
                _clientValidatorFake.Object);
        }
    }
}